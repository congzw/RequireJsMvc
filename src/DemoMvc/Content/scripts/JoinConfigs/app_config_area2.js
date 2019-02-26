require.config({
    paths: {
        'echarts': '/Content/scripts/demos/echarts.min'
    },
    shim: {
        'echarts': {
            exports: ['echarts']
        }
    }
});