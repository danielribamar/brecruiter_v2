var Menu = function () {

    var handleRender = function () {
        console.log('_handling render');

        $('.render-partial').click(function (event, element) {
            var btn = $(this);
            var ctrl = btn.data("ctrl");
            var action = btn.data("action");

            $.ajax({
                url: '/' + ctrl + '/' + action + '/',
                context: document.body
            }).done(function (data) {
                $('.content').fadeOut("slow", function () {
                    $(this).html(data);
                    $(this).fadeIn("slow");
                });
                $('.selected').removeClass('selected');
                btn.addClass('selected');
                $('.details').hide();
            });
        });

    };
    return {
        init: function () {
            handleRender();
        }
    };

}();

var Details = function () {

    var handleRender = function () {
        console.log('_handling render');

        $('.render-details').click(function (event, element) {

            var btn = $(this);
            var ctrl = btn.data("ctrl");
            var action = btn.data("action");
            var id = btn.data("id");
            $.ajax({
                url: '/' + ctrl + '/' + action + '/' + id,
                context: document.body
            }).done(function (data) {
                $('.details').fadeOut("slow", function () {
                    $(this).html(data);
                    $(this).fadeIn("slow");
                });
                $("#table-candidates tbody tr").removeClass('active');
                $('#' + id).addClass('active');
            });
        });

    };
    return {
        init: function () {
            handleRender();
        }
    };

}();

var Edit = function () {

    var handleEdit = function () {
        console.log('_handling edit');

        $('.save').click(function (event, element) {
            var id = $('#id').val();
            var email = $('#email').val();
            var firstName = $('#firstName').val();
            var lastName = $('#lastName').val();
            var wage = $('#wage').val();
            var experience = $('#experience').val();
            var available = $('#available').is(":checked");
            console.log(available);
            var observations = $('#observations').val();
            var languages = $('#languages').tagsinput('items');
            var tools = $('#tools').tagsinput('items');
            $.ajax({
                url: '/Candidates/Edit/',
                type: 'POST',
                data: {
                    id: id,
                    email: email,
                    firstName: firstName,
                    lastName: lastName,
                    wage: wage,
                    experience: experience,
                    available: available,
                    observations: observations,
                    languages: languages,
                    tools: tools
                },
                context: document.body
            }).error(function (data) {
                $('#message-error-body').html(data);
                $('#message-error').fadeIn("slow");
                $('#message-error').fadeOut(5000);
            }).success(function (data, statusText, xhr) {

                $('#' + data.id + '-email').html('<a href="mailto:' + data.email + '">' + data.email + '</a>');
                $('#' + data.id + '-firstname').html(data.firstName);
                $('#' + data.id + '-lastname').html(data.lastName);
                $('#' + data.id + '-wage').html(data.wage);
                $('#' + data.id + '-experience').html(data.experience);
                console.log(data.available);
                $('#' + data.id + '-available').html(data.available);

                if (xhr.status == 200) {
                    $('#message-success-body').html('O candidato ' + data.firstName + ' foi editado com sucesso.')
                    $('#message-success').fadeIn("slow");
                    $('#message-success').fadeOut(5000);

                }
            });


        });
    };
    return {
        init: function () {
            handleEdit();
        }
    };

}();

var Search = function () {
    var handleSearch = function () {
        console.log('_handling search');

        $('#submit_search').click(function (event, element) {

            console.log($(this));
            $.ajax({
                url: '/Candidates/search?query=qwery',
                type: 'GET',
                context: document.body
            }).error(function (data) {
                $('#message-error-body').html(data);
                $('#message-error').fadeIn("slow");
                $('#message-error').fadeOut(5000);
            }).success(function (data, statusText, xhr) {
                $('#search, #search button.close').removeClass('open');

                if (xhr.status == 200) {
                    $('#message-success-body').html('PESQUISA')
                    $('#message-success').fadeIn("slow");
                    $('#message-success').fadeOut(5000);

                }
            });


        });
    };
    return {
        init: function () {
            handleSearch();
        }
    };

}();