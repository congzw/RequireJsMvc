require.config({
    paths: {
        'myClock': '/Content/scripts/demos/MyClock'
    },
    shim: {
        myclock: {
            exports: "myClock"
        }
    }
});