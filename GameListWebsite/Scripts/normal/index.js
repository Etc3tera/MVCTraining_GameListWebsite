$(function () {
    var perPage = 20;

    var $genreList = $('#genreList');
    var $pageList = $('#pageList');
    var $gameTableBody = $('#gameTable').find('tbody');

    $.ajax({ url: '/GameList/JsonGetGenre' }).done(function (result) {
        $genreList.empty();
        $genreList.append('<option value="">All</option>');
        result.forEach(function (genre) {
            $genreList.append('<option value="' + genre + '">' + genre + '</option>');
        });

        
    });

    $genreList.on('change', function () {
        loadList($(this).val(), 0);
    });

    $pageList.on('change', function () {
        loadList($genreList.val(), $(this).val());
    });

    function loadList(genre, page) {
        $gameTableBody.empty();

        $.ajax({ url: '/GameList/JsonListGame?genre=' + genre + '&page=' + page }).done(function (result) {
            result.gameList.forEach(function (game) {
                $gameTableBody.append('<tr><td>' + game.Title + '</td><td>' + game.Publisher + '</td><td>' + game.Developer + '</td><td>' + "Detail" + '</td></tr>')
            });

            $pageList.empty();
            for (var i = 1; i <= result.numPage; i++) {
                $pageList.append('<option value="' + (i-1) + '">' + i + '</option>');
            }
        });
    }

    loadList('', 0);
});