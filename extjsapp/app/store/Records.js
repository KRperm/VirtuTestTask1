Ext.define('ExtJsApp.store.Records', {
    storeId: "records",
    extend: 'Ext.data.Store',
    alias: 'store.records',
    model: 'ExtJsApp.model.Record',
    autoLoad: true
});
