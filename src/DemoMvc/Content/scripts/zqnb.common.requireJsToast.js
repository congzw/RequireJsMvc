define(['jquery', 'toastr'], function ($, toastr) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-full-width",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "-1",
        "extendedTimeOut": "-1",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut",
        closeMethod: false
    };

    var toastMessage = function (msg) {
        toastr.info(msg, 'async load scripts:');
    };

    var showAsyncScripts = function () {

        $(function () {

            var scriptsInfo = "";
            $("script[async]").each(function () {
                scriptsInfo += "<p>" + this.src + "</p>";
            });
            toastMessage(scriptsInfo);
        });
    };

    return {
        showAsyncScripts: showAsyncScripts
    };
});