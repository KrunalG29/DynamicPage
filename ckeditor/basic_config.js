/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	//config.language = 'fr';
    //config.uiColor = '#AADC6E';
    config.toolbar = 'Full';
    config.toolbar_Full=
	[
	    { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] }	
	];
    config.removePlugins = 'about,save';
    config.removePlugins = 'elementspath';    
    
    
};
