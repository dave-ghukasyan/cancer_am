window.put = function(url, data) {
    let init = {
        method: "PUT",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    };
    
    return fetch(url, init);
}

window.post = function(url, data) {
    let init = {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return fetch(url, init);
}

window.delete = function(url) {
    return fetch(url, {method: "DELETE"});
}







