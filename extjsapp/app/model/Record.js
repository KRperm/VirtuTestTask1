Ext.define('ExtJsApp.model.Record', {
    extend: 'ExtJsApp.model.Base',

    fields: [
        { name: 'id', type: 'string' },
        { name: 'name', type: 'string' },
        { name: 'dateOfBirth', type: 'date', dateFormat: 'C' },
        { name: 'phone', type: 'string' }
    ],

    proxy: {
        type: 'rest',
        url : 'https://localhost:7268/api/records',
        cors: true,
        useDefaultXhrHeader: false
    }
});
