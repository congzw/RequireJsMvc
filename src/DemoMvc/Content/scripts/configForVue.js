require.config({
    paths: {
        'jquery': '/Content/libs/jquery/jquery-2.1.0'
        , 'toastr': '/Content/libs/toastr/toastr'
        , 'bootstrap': '/Content/libs/bootstrap/bootstrap'
        , 'zqnb': '/Content/scripts/zqnb'
        , 'nbLog': '/Content/scripts/zqnb.log'
        , 'vue': '/Content/libs/vue/js/vue'
        , 'axios': '/Content/libs/vue/js/axios'
        , 'httpVueLoader': '/Content/libs/vue/js/httpVueLoader'
        , 'ELEMENT': '/Content/libs/vue/element-ui/index'
        //1 ��Ϊindex.js��ģ�������Ѿ�����ΪELEMENT����д�����Ա����ELEMENT������������������
        //2 ������ʱ��Ҫд Vue.use(ELEMENT);
        , 'spaceEntry': '/Content/scripts/space.entry'
    },
    shim: {
        vue: {
            exports: "Vue"
        }
        ,bootstrap: {
            deps: ["jquery"]
        }
        , httpVueLoader: {
                exports: "httpVueLoader"
            , deps: ["axios"]
        }
        , ELEMENT: {
            exports: "ELEMENT"
            , deps: ["vue"]
        }
    }
});

require(['spaceEntry'], function () {
    console.log('spaceEntry');
});