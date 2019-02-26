require.config({
    paths: {
        'jquery': '/Content/libs/jquery/jquery-2.1.0',
        'toastr': '/Content/libs/toastr/toastr',
        'bootstrap': '/Content/libs/bootstrap/bootstrap',
        'zqnb': '/Content/scripts/zqnb',
        'nbLog': '/Content/scripts/zqnb.log'
    },
    shim: {
        bootstrap: {
            deps: ["jquery"]
        }
    }
});