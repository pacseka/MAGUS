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
            var vm = new WeaponViewModel(null, dataModel);
            var weaponArraySpy = spyOn(vm, "weaponArray");

            jasmine.Ajax.stubRequest(dataModel.weaponUrl + "/get?category=melee").andReturn({
                "responseText": '{"Teszt":"erd"}'
            });

            var result = vm.getAll();
            expect(weaponArraySpy).toHaveBeenCalledWith({ "Teszt": "erd" });
        });

        it("teszt eset", function () {

            var vm = new WeaponViewModel(null, dataModel);

            spyOn(vm, "getAll").and.returnValue(6);

            expect(vm.get()).toBe(6);
        });
    });


    describe("Callback teszt", function () {
        var dataModel = new AppDataModel();

        beforeEach(function () {
            jasmine.Ajax.install();
        });

        afterEach(function () {
            jasmine.Ajax.uninstall();
        });

        it("Count callback", function () {
            var vm = new WeaponViewModel(null, dataModel);

            var spyCount = spyOn(vm, "count");

            jasmine.Ajax.stubRequest("/teszt/callback").andReturn({
                "responseText": '{"Count": 200}'
            });

            MAGUS.GetCountFromServer("Alma", vm.count);

            //vm.getCount();

            expect(spyCount).toHaveBeenCalledWith(200);
        });

        it("Indirect call count", function () {
            var vm = new WeaponViewModel(null, dataModel);

            var spyCount = spyOn(vm, "count");

            jasmine.Ajax.stubRequest("/teszt/callback").andReturn({
                "responseText": '{"Count": 200}'
            });

            vm.getCount();

            expect(spyCount).toHaveBeenCalledWith(200);

        });
    });
});