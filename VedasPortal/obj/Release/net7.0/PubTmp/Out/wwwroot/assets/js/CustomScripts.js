// javascript function to download file
function downloadFile(fileDataUrl) {
    // call the javascript fetch api to get the file
    fetch(fileDataUrl)
        .then(response => response.blob())
        .then(blob => {

            //create a link element that we shall programatically click 
            var link = window.document.createElement("a");
            link.href = window.URL.createObjectURL(blob);
            // generate the download file name
            link.download = "download_" + new Date().toISOString().slice(0, 10);

            //add the link, click to download and remove the link
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        });
}