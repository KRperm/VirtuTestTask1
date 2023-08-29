/*
 * This file launches the application by asking Ext JS to create
 * and launch() the Application class.
 */
Ext.application({
    extend: 'ExtJsApp.Application',

    name: 'ExtJsApp',

    requires: [
        // This will automatically load all classes in the ExtJsApp namespace
        // so that application classes do not need to require each other.
        'ExtJsApp.*'
    ],

    // The name of the initial view to create.
    mainView: 'ExtJsApp.view.main.Main'
});
