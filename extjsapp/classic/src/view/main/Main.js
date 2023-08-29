Ext.define('ExtJsApp.view.main.Main', {
    extend: 'Ext.panel.Panel',
    xtype: 'app-main',

    requires: [
        'Ext.plugin.Viewport',
        'Ext.window.MessageBox',

        'ExtJsApp.view.main.MainController',
        'ExtJsApp.view.main.MainModel',
        'ExtJsApp.view.main.List'
    ],

    controller: 'main',
    viewModel: 'main',

    ui: 'navigation',

    items: [
        { xtype: 'mainlist' }
    ]
});
