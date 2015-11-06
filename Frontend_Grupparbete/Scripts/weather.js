
// GEOCODER
function getCoordinatesGeocoder(place, callback) {
    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': place }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            callback(results[0].geometry.location.lat(), results[0].geometry.location.lng());
        } else {
            alert('Invalid address: ' + place);
        }
    });
}

function getLocationGeocoder(latitude, longitude, callback) {
    var geocoder = new google.maps.Geocoder();
    var latlng = { lat: latitude, lng: longitude };

    geocoder.geocode({ 'location': latlng }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            if (results[1]) {
                callback(results[1].formatted_address);
            } else {
                alert('No results found');
            }
        } else {
            alert('Geocoder failed due to: ' + status);
        }
    });
}

// -----------------------------------------------------------------------------------
// LOCAL STORAGE
function getWeatherFromLocalStorage(latitude, longitude) {
    var value = $.parseJSON(localStorage.getItem(getLocalStorageKey(latitude, longitude)));
    if (value && (new Date()).getTime() < value.time) {
        return value.data;
    }
}
function addWeatherToLocalStorage(latitude, longitude, data) {
    var now = new Date();
    var expires = now.setHours(now.getHours() + 1);
    localStorage.setItem(
        getLocalStorageKey(latitude, longitude),
        JSON.stringify({ time: expires, data: data }));
}
function getLocalStorageKey(latitude, longitude) {
    return latitude.toFixed(4) + '&' + longitude.toFixed(4);
}

// -----------------------------------------------------------------------------------
// WEATHER-API
function getWeatherFromApi(latitude, longitude, onSuccess, onComplete) {
    $.ajax({
        url: 'https://api.forecast.io/forecast/44c7cdd00e0f82699006ed275eb2b6cf/' + latitude + ',' + longitude + '?units=si',
        type: 'GET',
        dataType: 'jsonp',
        success: function (data, textStatus, xhr) {
            onSuccess(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        },
        complete: function () {
            onComplete();
        }
    });
}

// -----------------------------------------------------------------------------------
// UPDATE CURRENT-WEATHER
function updateCurrentWeather(json, url, onSuccess) {
    var currently = json.currently;

    var jsonNow = {
        time: currently.time,
        summary: currently.summary,
        icon: currently.icon,
        temperature: currently.temperature,
        apparentTemperature: currently.apparentTemperature,
        cloudCover: currently.cloudCover,
        precipIntensity: currently.precipIntensity,
        precipProbability: currently.precipProbability,
        windSpeed: currently.windSpeed,
        windBearing: currently.windBearing
    };
    $.ajax({
        url: url,
        type: 'get',
        data: jsonNow,
        datatype: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            onSuccess(data);
        },
        error: function (request, status, err) {
            //alert(status);
            //alert(err);
        }
    });
}

// -----------------------------------------------------------------------------------
// UPDATE DAILY-WEATHER
function updateDailyWeather(json, url, onSuccess) {
    var daily = json.daily;

    $.each(daily.data, function (i, item) {

        var jsonDaily = {
            time: item.time,
            summary: item.summary,
            icon: item.icon,
            temperatureMax: item.temperatureMax,
            temperatureMaxTime: item.temperatureMaxTime,
            temperatureMin: item.temperatureMin,
            temperatureMinTime: item.temperatureMinTime,
            cloudCover: item.cloudCover,
            precipIntensity: item.precipIntensity,
            precipIntensityMax: item.precipIntensityMax,
            precipProbability: item.precipProbability,
            windSpeed: item.windSpeed,
            windBearing: item.windBearing,
            sunriseTime: item.sunriseTime,
            sunsetTime: item.sunsetTime,
            moonPhase: item.moonPhase
        };
        $.ajax({
            url: url,
            type: 'get',
            data: jsonDaily,
            datatype: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                onSuccess(data, i);
            },
            error: function (request, status, err) {
                //alert(status);
                //alert(err);
            }
        });
    });
}

// -----------------------------------------------------------------------------------
// UPDATE HOURLY-WEATHER
function updateHourlyWeather(json, url, onSuccess) {
    var hourly = json.hourly;

    $.each(hourly.data, function (i, item) {

        var jsonHourly = {
            time: item.time,
            summary: item.summary,
            icon: item.icon,
            temperature: item.temperature,
            apparentTemperature: item.apparentTemperature,
            cloudCover: item.cloudCover,
            precipIntensity: item.precipIntensity,
            precipProbability: item.precipProbability,
            windSpeed: item.windSpeed,
            windBearing: item.windBearing
        };
        $.ajax({
            url: url,
            type: 'get',
            data: jsonHourly,
            datatype: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                onSuccess(data, i);
            },
            error: function (request, status, err) {
                //alert(status);
                //alert(err);
            }
        });
    });
}