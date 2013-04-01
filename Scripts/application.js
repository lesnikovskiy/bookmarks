(function ($) {
    function BookmarkDTO(title, url) {
        this.Title = title;
        this.Url = url;
    }

    function Bookmark(bookmark) {
        this.id = ko.observable(bookmark.Id);
        this.title = ko.observable(bookmark.Title);
        this.url = ko.observable(bookmark.Url);
    }

    function BookmarkViewModel() {
        var self = this;
        self.bookmarks = ko.observable([]);
        self.addBookmark = function () {
            var bookmark = new BookmarkDTO($('#title').val(), $('#url').val());
            $.ajax({
                url: '/api/bookmark',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: ko.toJSON(bookmark),
                success: function (data) {
                    var bookmarks = self.bookmarks();
                    if (!bookmarks.length) return;
                    
                    bookmarks.push(new Bookmark(data));
                    self.bookmarks(bookmarks);
                }
            });
        };

        $.getJSON('/api/bookmark', function(data) {
            var mapped = $.map(data, function(i) {
                return new Bookmark(i);
            });

            self.bookmarks(mapped);
        });
    }

    $(document).ready(function() {
        ko.applyBindings(new BookmarkViewModel());
    });
})(jQuery);

/*(function() {
    var Bookmark = Backbone.Model.extend({
        url: '/api/bookmark',
        defaults: {
            Title: 'test',
            Url: 'http://test.com'
        }
    });

    var BookmarkView = Backbone.View.extend({
        el: $('#edit-bookmark'),
        initialize: function() {
            _.bindAll(this, 'render');
        },
        render: function() {
            var template = _.template($('#edit-bookmark-template').html());
            this.$el.html(template);
        },
        events: {
            'submit #bookmark-form': 'triggerBookmark'
        },
        triggerBookmark: function (e) {
            debugger;
            e.preventDefault();
            
            this.model.save({
                Title: $('#title').val(),
                Url: $('#url').val()
            }, {
                success: function(model) {
                    console.log(model);
                }
            });
        }
    });
    
    var Bookmarks = Backbone.Collection.extend({ model: Bookmark });
    var BookmarksView = Backbone.View.extend({
        el: $('#bookmarks'),
        initialize: function() {
            _.bindAll(this, 'render');
        },
        render: function () {
            this.collection = new Bookmarks;
            this.collection.on('add', renderBookmark, this);

            var template = _.template($('#bookmarks-template').html());
            this.$el.html(template);
        },
        renderBookmark: function (bookmark) {
            this.$el.find('.bookmrks').append($('<li />', { text: bookmark.get('title') }));
        }
    });

    var bookmarkView = new BookmarkView({model: new Bookmark});
    bookmarkView.render();
})(jQuery);*/