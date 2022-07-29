window.initWebViewer = (pdfUrl) => {
    WebViewer({
        path: 'lib',
        licenseKey: 'ECsEG9yby6XpiiqaZmJY',
        initialDoc: pdfUrl
    }, document.getElementById('viewer')).then((instance) => {
        const { Core, UI } = instance;
    });
};
