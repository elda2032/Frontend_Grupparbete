userFormApp.controller('homeController',
    function homeController($scope, $modal, dataService) {

        $scope.showCreateUserForm = function () {
            $modal.open({
                templateUrl: "/app/UserForm/userTemplate.html",
                controller: "userController",
                resolve: { id: 0 }
            });
        }

        $scope.showUpdateUserForm = function (id) {
            $modal.open({
                templateUrl: "/app/UserForm/userTemplate.html",
                controller: "userController",
                resolve: { id: id }
            });
        }


    });