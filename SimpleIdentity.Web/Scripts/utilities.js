(function () {
    $("#bodyWrapper").on('click', '#loginSignUpBtn', function (event) {
        event.preventDefault();
        var form = $('#loginSignUpForm');
        var url = form.attr('action');
        $('#errorMessage').empty();

        if (form.valid()) {
            var postData = form.serializeArray();
            $.ajax(
            {
                url: url,
                type: "POST",
                data: postData,
                success: function (data) {
                    if (data.URL) {
                        window.location.href = data.URL;
                        console.log(data);
                    }
                },
                error: function (errorData) {
                    $('#errorMessage').html(errorData.statusText);
                    console.log(errorData.statusText);
                }
            });
        }
    })
})()