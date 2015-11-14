userFormApp.controller('userController', ["$scope", "dataService","$modalInstance","id",
    function ($scope, dataService, $modalInstance, id) {

        if (id === 0)
        {
            $scope.user = { Id: 0 };
            $scope.editableUser = angular.copy($scope.user);
            $scope.headline = "Create new User";
        }
        else {
            dataService.getUser(id).then(
                function(results) {
                    //Success function
                    var data = results.data;
                    $scope.user = data;
                    $scope.editableUser = angular.copy($scope.user);
                },
                function(results) {
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
                    $scope.user = angular.copy($scope.editableUser);
                    $scope.SuccessMessage = results.statusText;
                },
                function (results) {
                    $scope.ErrorMessage = results.statusText;
                });
        }

        $scope.cancelForm = function () {
            $modalInstance.dismiss();
        }
    }]);