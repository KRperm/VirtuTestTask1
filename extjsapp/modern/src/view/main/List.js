/**
 * This view is an example list of people.
 */
Ext.define('ExtJsApp.view.main.List', {
    extend: 'Ext.grid.Grid',
    xtype: 'mainlist',

    requires: [
        'ExtJsApp.store.Personnel'
    ],

    title: 'Personnel',

    store: {
        type: 'personnel'
    },

    columns: [{ 
        text: 'Name',
        dataIndex: 'name',
        editor: 'textfield',
        width: 100,
        cell: {
            userCls: 'bold'
        }
    }, {
        text: 'Email',
        dataIndex: 'email',
        editor: 'textfield',
        width: 230 
    }, { 
        text: 'Phone',
        dataIndex: 'phone',
        editor: 'textfield',
        width: 150 
    }]
});
