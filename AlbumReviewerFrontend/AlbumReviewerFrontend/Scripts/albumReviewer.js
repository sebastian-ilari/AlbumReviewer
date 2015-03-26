$(function () {
    var frontendUrl = "http://localhost:2208/Home/",
        animationSpeed = 200;

    var getAlbums = function () {
        var $artist = $(this),
			li = $artist.parent(),
			artistId = li.data("artist-id"),
            albumsAreLoaded = ($artist.find('[data-id="album"]').length > 0),
            $albumsContainer = $(li.find('[data-id="albumsContainer"]')),
            $allAlbumsContainer = $('li div[data-id="albumsContainer"]'),
            albumsAreVisible = $albumsContainer.is(":visible");

        if (albumsAreVisible)
        {
            $albumsContainer.slideToggle(animationSpeed, undefined);
            return;
        }

        $allAlbumsContainer.slideUp(animationSpeed).promise().done(function() {
            
            if (!albumsAreLoaded) {
                var options = {
                    url: frontendUrl + "GetAlbumsFromArtist?artistId=" + artistId,
                    type: 'GET',
                };

                $.ajax(options).done(function (result) {

                    $albumsContainer.hide().html(result).slideDown(animationSpeed);

                    $albumsContainer.find('[data-id="starsContainer"] img').on('click', function () {
                        saveAlbumsRating(this, result, $albumsContainer);
                    });
                });
            }
            else {
                $albumsContainer.slideToggle(animationSpeed, undefined);
            }
        });
    };

    var saveAlbumsRating = function ( starImg, albums, $albumsContainer ) {
        albumId = $(starImg).data('album-id'),
        rating = $(starImg).data('position'),

        //TODO: this should receive the albums instead of the PartialView
        album = $.grep(albums, function (e) { return e.AlbumId == albumId; })[0];

    };

    // Bind events
    $('div[data-id="artist"]').on('click', getAlbums);
});