window.initWebViewer = (key, pdfUrl) => {
    WebViewer({
        path: 'lib',
        licenseKey: key,
        initialDoc: pdfUrl
    }, document.getElementById('viewer')).then((instance) => {
        instance.UI.disableElements(['selectToolButton']);
        instance.UI.disableElements(['viewControlsButton']);
        instance.UI.disableElements(['panToolButton']);
        instance.UI.setToolMode('Pan');
        const { documentViewer } = instance.Core;
        documentViewer.addEventListener('toolModeUpdated', () => {
            instance.UI.setToolMode('Pan');
        });
    });
};
