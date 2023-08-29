/**
 * This view is an example list of people.
 */
Ext.define('ExtJsApp.view.main.List', {
    extend: 'Ext.grid.Panel',
    xtype: 'mainlist',

    requires: [
        'ExtJsApp.store.Records',
    ],

    title: 'Записи',
    height: 600,

    store: {
        type: 'records'
    },

    plugins: [{
        ptype: 'rowediting',
        clicksToMoveEditor: 1,
        clicksToEdit: 1,
        autoCancel: false,
        listeners: {
            edit: 'onItemEdited'
        }
    }],

    tbar: [{
        text: 'Добавить',
        handler: 'onAddClick'
    }],

    columns: [
        { 
            text: 'ФИО',
            dataIndex: 'name',
            editor: 'textfield'
        },
        { 
            text: 'Дата рождения', 
            dataIndex: 'dateOfBirth', 
            flex: 1, 
            format: 'd.m.Y',
            xtype: 'datecolumn', 
            editor: {
                xtype: 'datefield',
                format: 'd.m.Y'
            } 
        },
        { 
            text: 'Телефон',
            dataIndex: 'phone',
            flex: 1,
            editor: 'textfield' 
        },
        {
            xtype: 'actioncolumn',
            width: 30,
            sortable: false,
            menuDisabled: true,
            items: [{
                iconCls: 'x-fa fa-trash',
                tooltip: 'Удалить запись',
                handler: 'onRemoveClick'
            }]
        }
    ]
});
