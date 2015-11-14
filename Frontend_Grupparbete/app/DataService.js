userFormApp.factory("dataService", ["$http", function ($http) {

    var getUser = function (id) {
        return $http.get("/Login/GetUser/" + id);
    };
    var addOrUpdateUser = function (user) {
        return $http.post("/Login/UpdateUser", user);
    }
    var loginUser = function(user) {
        return $http.post("/Login/Login", user);
    }
    var tryGetLoggedInUser = function() {
        return $http.get("/Login/TryGetLoggedInUser");
    }
    var logout = function() {
        return $http.get("/Login/Logout");
    }
    var deleteUser = function (id) {
        console.log(id);
        return $http.post("/Login/RemoveUser/" + id);
    }

    return {
        getUser: getUser,
        addOrUpdateUser: addOrUpdateUser,
        loginUser: loginUser,
        tryGetLoggedInUser: tryGetLoggedInUser,
        logout: logout,
        deleteUser: deleteUser
    };
}])