var fareApp = angular.module('fareApp', []);

fareApp.factory('rideService', ['$http', function ($http) {
    return {
        getFare: function (ride) {
            return $http({
                method: 'POST',
                url: '/api/FareService/CalculateFarePrice',
                data: $.param(ride),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
}]);

fareApp.directive('numValid', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        template: '<input type="number" class="form-control" style="max-width:325px;"/>',
        replace: true,
        link: function (scope, element, attr, ctrl) {

            ctrl.$parsers.push(function (value) {
                var isValid = value >= 0;
                ctrl.$setValidity('postive', isValid);
                return isValid ? value : undefined;
            });


        }
    }
});

fareApp.controller('fareController', ['$scope', 'rideService', function ($scope, rideService) {
    $scope.submit = function () {
        var ride = {
            Miles: $scope.ride.miles,
            Minutes: $scope.ride.minutes,
            StartDateTime:
                new Date(
                    $scope.ride.startdate.getYear(),
                    $scope.ride.startdate.getMonth(),
                    $scope.ride.startdate.getDate(),
                    $scope.ride.starttime.getHours(),
                    $scope.ride.starttime.getMinutes())
                .toUTCString(),
            State: $scope.ride.state
        };
        rideService.getFare(ride).then(function (resp) {
            $scope.cost = resp.data.cost.toFixed(2);
        }, function (data) {
            console.error(data);
        });

    };
}]);