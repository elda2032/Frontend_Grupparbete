var userFormApp = angular.module('userFormApp', ['ui.bootstrap']);

userFormApp.directive('loginMenu', function () {
    return {
        restrict: "E",
        templateUrl: "/app/loginMenuTemplate.html"
    }
});