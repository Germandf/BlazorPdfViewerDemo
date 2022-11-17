window.initWebViewer = (key, pdfUrl, error) => {
    WebViewer({
        path: 'lib',
        licenseKey: key,
        initialDoc: pdfUrl
    }, document.getElementById('viewer')).then((instance) => {
        instance.UI.disableElements(['selectToolButton']);
        instance.UI.disableElements(['viewControlsButton']);
        instance.UI.disableElements(['panToolButton']);
        instance.UI.disableElements(['searchButton']);
        instance.UI.disableElements(['thumbnailsSizeSlider']);
        instance.UI.disableElements(['thumbnailsPanelButton']);
        instance.UI.disableElements(['leftPanelTabs']);
        instance.UI.setLanguage('es');
        instance.UI.setToolMode('Pan');
        instance.UI.iframeWindow.addEventListener('loaderror', (err) => {
            instance.showErrorMessage(error);
        });
        const { documentViewer } = instance.Core;
        documentViewer.addEventListener('toolModeUpdated', () => {
            instance.UI.setToolMode('Pan');
        });
    });
};
