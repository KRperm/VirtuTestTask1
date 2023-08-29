/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('ExtJsApp.view.main.MainController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.main',

    onItemEdited: function (editor, context) {
        context.record.save();
    },

    onAddClick: function (view) {
        var store = Ext.getStore("records");
        store.add({
            name: "Новый клиент",
            dateOfBirth: new Date(2000, 0, 1),
            phone: "+7 xxx xxx xx xx"
        });
        store.sync();
        store.load();
    },

    onRemoveClick: function(view, recIndex, cellIndex, item, e, record) {
        record.erase()
    }
});
