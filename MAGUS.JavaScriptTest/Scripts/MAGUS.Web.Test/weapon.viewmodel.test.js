

describe("Test Web JS", function () {
    describe("Meele handling test", function () {
        var dataModel = new AppDataModel();


        beforeEach(function () {
            jasmine.Ajax.install();
        });

        afterEach(function () {
            jasmine.Ajax.uninstall();
        });

        it("get melees from server", function () {
            var vueVM = weaponvue;

            jasmine.Ajax.stubRequest(dataModel.weaponUrl + "/search").andReturn({
                "responseText": '[{"Name":"Kahrei nypk", "Initiate":"10", "Cost":"200"}]'
            });

            var result = vueVM.FindWeapon();
            expect(vueVM.weapons.length).toBe(1);
        });
    });
});