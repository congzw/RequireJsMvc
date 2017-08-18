require(['mainApp', 'nbLog'], function (mainApp, nbLog) {
    nbLog.debug("angular.index.js");
    mainApp.controller('demoCtrl', function ($scope) {
        $scope.message = "from angular controller!";
    });
});