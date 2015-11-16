userFormApp.controller('userController', ["$scope", "dataService", "$modalInstance", "id","$controller",
    function ($scope, dataService, $modalInstance, id, $controller) {

        var homeController = $scope.$new();
        $controller('homeController', { $scope: homeController });

        if (id === 0) {
            $scope.user = { Id: 0 };
            $scope.editableUser = angular.copy($scope.user);
            $scope.headline = "Create new User";
        }
        else {
            dataService.getUser(id).then(
                function (results) {
                    //Success function
                    var data = results.data;
                    $scope.user = data;
                    $scope.editableUser = angular.copy($scope.user);
                },
                function (results) {
                    //fail function
                    $scope.ErrorMessage = results.statusText;
                });
            $scope.headline = "Edit User (" + id + ")";
        }

        $scope.professions = [
            "Apple",
            "McDonalds",
            "Blizzard"
        ];


        $scope.submitForm = function () {
            dataService.addOrUpdateUser($scope.editableUser).then(
                function (results) {
                    if (results.data.success) {
                        $scope.user = results.data.user;
                        $scope.editableUser = angular.copy($scope.user);
                        $scope.SuccessMessage = results.data.message;
                        $scope.headline = "Edit User (" + $scope.user.Id + ")";
                    } else {
                        $scope.user = angular.copy($scope.editableUser);
                        $scope.SuccessMessage = results.statusText;
                    }
                },
                function (results) {
                    $scope.ErrorMessage = results.statusText;
                });
        }

        $scope.cancelForm = function () {
            $modalInstance.dismiss();
        }

        $scope.deleteUser = function (id) {
            dataService.deleteUser(id).then(
                function(results) {
                    if (results.data.success) {
                        $scope.user = { Id: 0 };
                        $scope.editableUser = angular.copy($scope.user);
                        $scope.headline = "Create new User";
                        $scope.SuccessMessage = results.data.message;
                        homeController.updateLoginMenu();
                    } else {
                        $scope.ErrorMessage = results.data.message;
                    }
                });
        }

        $scope.loginUser = function (email, password) {
            dataService.loginUser({ Email: email, Password : password }).then(
                function (results) {
                    if (results.data.success) {
                        $scope.SuccessMessage = results.data.message;
                        homeController.updateLoginMenu();
                    } else {
                        $scope.ErrorMessage = results.data.message;
                    }
                });
        }
    }]);