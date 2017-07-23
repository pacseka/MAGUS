/// <reference path="app.datamodel.js" />
/// <reference path="app.viewmodel.js" />

/**
 * Fegyver view model
 * @public
 * @class WeaponViewModel
 * @constructor
 * @param {any} app - Alkalmazás
 * @param {any} dataModel - Adatmodell
 */
function WeaponViewModel(app, dataModel) {
    var self = this;
    
    self.count = ko.observable();

    self.getCount = function () {
        MAGUS.GetCountFromServer("Nev", self.count);
    }


    /**
     * WeaponEdit objektum 
     * @memberof WeaponViewModel
     * @public
     * @member WeaponEdit
     * @see {@link WeaponEdit}
     * @instance
     */
    self.WeaponEdit;

    /**
    * Init
    * @public
    * @method initialize
    * @memberof WeaponViewModel
    * @instance
    */
    self.initialize = function () {
        $("#tbMeleeWeapon").DataTable({
            "ajax": {
                "url": dataModel.weaponUrl + "/get?category=melee",
                "dataSrc": "",
            },
            "columns": [
                { "data": "Name" }
            ]
        });

        self.getAll();
    }

    /**
    * Get minden fegyvert
    * @memberof WeaponViewModel
    * @method get
    * @instance
    */
    self.get = function () {
        return self.getAll();
    }

    self.getAll = function () {
        $.ajax({
            url: dataModel.weaponUrl + "/get?category=melee",
            contentType: "application/json",
            method: "GET",
            dataType: "json"
        }).done(function (responseText) {
            self.weaponArray(responseText);
        }).fail(function (result) {
            console.log(result);
        });
    }

    return self;
}

var MAGUS = {

    GetCountFromServer: function (name, callback) {
        $.ajax({
            url: "/teszt/callback"
        }).done(function (result) {
            callback(result.Count);
        });
    }
}

/**
 * @class WeaponEdit
 */
function WeaponEdit() {
    var self = this;

    return self;
}