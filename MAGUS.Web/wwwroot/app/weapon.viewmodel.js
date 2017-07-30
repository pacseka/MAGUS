/// <reference path="app.datamodel.js" />
/// <reference path="app.viewmodel.js" />


var weaponvue = new Vue({
    el: '#weaponvue',
    methods: {
        Init: function (dataModel) {
            $("#tbMeleeWeapon").dataTable({
                "ajax": {
                    "url": dataModel.weaponUrl + "/search",
                    "dataSrc": "",
                    "type": "POST",
                    "contentType": "application/json",
                    "dataType": "json",
                    "data": function () { return JSON.stringify({ Name: "Kahrei", Initiate: { Min: 0, Max: 10 } }); }
                },
                "columns": [
                    { "data":"Name" },
                    { "data": "Initiate" },
                    { "data": "Cost" }
                ]
            });
        },

        GetAll: function () {
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
    }
});

var dataModel = new AppDataModel();

weaponvue.Init(dataModel);