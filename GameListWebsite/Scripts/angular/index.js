var app = angular.module('gameListApp', []);

app.controller('mainController', function ($scope, $http) {
    $scope.genreList = ["All"];
    $scope.genre = "All";
    $scope.gameList = [];
    $scope.pageList = [];

    $scope.refreshGameList = function () {
        var genre = $scope.genre == "All" ? "" : $scope.genre;
        var page = typeof $scope.page == 'undefined' ? 0 : $scope.page.value;
        $http.get('/GameList/JsonListGame?genre=' + genre + '&page=' + page).success(function (result) {
            $scope.gameList = result.gameList;
            var pList = [];
            for (var i = 1; i <= result.numPage; i++) {
                pList.push({ label: i, value: i - 1 });
            }
            $scope.pageList = pList;
            $scope.page = $scope.pageList[0];
        });
    }

    // ------------- Initialize
    $http.get('/GameList/JsonGetGenre').success(function (result) {
        $scope.genreList.push.apply($scope.genreList, result);
    });
    $scope.refreshGameList();

});

app.filter('pprint', function () {
    return function (input) {
        if (input instanceof Array) {
            return input.join(', ');
        }
    };
});