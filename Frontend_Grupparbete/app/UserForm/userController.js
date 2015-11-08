userFormApp.controller('userController',
    function userController($scope, userService) {
        $scope.user = userService.user;
        $scope.professions = [
            "Apple",
            "McDonalds",
            "Blizzard"
        ];

        $scope.submitForm = function() {
        }

    });