var fareApp = angular.module('fareApp', []);

fareApp.factory('rideService', ['$http', function ($http) {
    return {
        getFare: function (ride) {
            return $http({
                method: 'POST',
                url: '/api/fareService/calculate',
                data: $.param(ride),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
}]);

far.directive('numCheck', function () {
    return {
        restrict: 'E',
        require: 'ngModel',
        template: '<input type="text" />',
        replace: true,
        link: function (scope, element, attr, ctrl) {

            ctrl.$parsers.push(function (value) {
                //regex from angular source
                var NUM_REGEX = /^\s*(\-|\+)?(\d+|(\d*(\.\d*)))\s*$/;
                var validity = NUM_REGEX.test(value);
                ctrl.$setValidity('number', validity);
                return validity ? value : undefined;
            });


        }
    }
});

function fareController($scope, rideService) {

    $scope.processForm = function () {
        var ride = {
            miles: $scope.ride.miles,
            minutes: $scope.ride.minutes,
            startdatetime:
                new Date(
                    $scope.ride.startdate.getYear(),
                    $scope.ride.startdate.getMonth(),
                    $scope.ride.startdate.getDate(),
                    $scope.ride.starttime.getHours(),
                    $scope.ride.starttime.getMinutes())
                .toUTCString()
        };
        console.log(ride);
        rideService.getFare(ride).then(function (data) {
            $scope.cost = data.data.cost.toFixed(2);
        }, function (data) {
            console.log(data);
            console.error(data);
        });

    };

}

