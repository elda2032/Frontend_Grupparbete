userFormApp.controller('loginController', ["$scope", "dataService", "$modalInstance", "$controller",
    function ($scope, dataService, $modalInstance, $controller) {

        var homeController = $scope.$new(); 
        $controller('homeController', { $scope: homeController });

        $scope.user = {
            Email: "",
            Password: ""
        };

        $scope.submitForm = function () {
            dataService.loginUser($scope.user).then(
                function(results) {
                    if (results.data.success) {

                        $modalInstance.dismiss();
                        homeController.updateLoginMenu();

                    } else {
                        $scope.ErrorMessage = results.data.message;
                        $scope.user.Password = "";
                    }
                },
                function(results) {
                    $scope.ErrorMessage = results.message;
                    $scope.user.Password = "";
                });
        }

        $scope.cancelForm = function () {
            $modalInstance.dismiss();
        }
    }]);