require.config({
    paths: {
        'jquery': '/Content/libs/jquery/jquery-2.1.0'
        , 'toastr': '/Content/libs/toastr/toastr'
        , 'angular': '/Content/libs/angular/angular'
        , 'ngRoute': '/Content/libs/angular/angular-route'
        , 'bootstrap': '/Content/libs/bootstrap/bootstrap'
        , 'zqnb': '/Content/scripts/zqnb'
        , 'nbLog': '/Content/scripts/zqnb.log'
        , 'mainApp': '/Content/scripts/mainApp'
        , 'aceElements': '/Content/libs/ace/assets/js/ace-elements'
        , 'aceExtra': '/Content/libs/ace/assets/js/ace-extra'
        , 'ace': '/Content/libs/ace/assets/js/ace'
    },
    shim: {
        angular: {
            exports: "angular"
            //,deps: ["jquery"]
        },
        ace: {
            exports: "ace"
            , deps: ["aceExtra", "aceElements", "bootstrap"]
        },
        ngRoute: {
            deps: ["angular"]
        }
    }
});