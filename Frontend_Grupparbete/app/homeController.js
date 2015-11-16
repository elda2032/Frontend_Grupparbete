userFormApp.controller('homeController', ["$scope", "dataService", "$modal", "$rootScope",
    function homeController($scope, dataService, $modal, $rootScope) {

        $rootScope.login = {};
        updateMenu();

        function updateMenu() {
            dataService.tryGetLoggedInUser().then(
            function (results) {
                if (results.data.success) {
                    $rootScope.login.loggedin = true;
                    $rootScope.login.notloggedin = false;
                    $rootScope.login.loggedInUser = results.data;
                } else {
                    $rootScope.login.loggedin = false;
                    $rootScope.login.notloggedin = true;
                    $rootScope.login.loggedInUser = { email: "", id: "" };
                }
            });
        }

        $scope.updateLoginMenu = function () {
            updateMenu();
        }

        $scope.logoutUser = function() {
            dataService.logout().then(
                function(results) {
                    updateMenu();
                });
        }

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

        $scope.showLoginForm = function () {
            $modal.open({
                templateUrl: "/app/LoginForm/loginTemplate2.html",
                controller: "loginController"
            });
        }
    }]);