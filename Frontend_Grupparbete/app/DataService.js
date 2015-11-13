userFormApp.factory("dataService", ["$http", function ($http) {

    var getUser = function (id) {
        return $http.get("/Login/GetUser/" + id);
    };
    var addOrUpdateUser = function (user) {
        return $http.post("/Login/UpdateUser", user);
    }

    return {
        getUser: getUser,
        addOrUpdateUser: addOrUpdateUser
    };
}])