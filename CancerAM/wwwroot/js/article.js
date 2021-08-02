const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});

function showNewArticleDialog(categoryId) {
    Metro.dialog.create({
        overlay: "true",
        title: "Create a new chapter",
        content: `<input type=\"text\" data-role=\"input\" placeholder="title" id="articleTitleInputVal">
                  <hr />
                  <input type="file" data-role="file" data-prepend="Select article picture:" id="pictureVal">`,
        closeButton: true,
        actions: [
            {
                caption: "Create",
                cls: "js-dialog-close success",
                onclick: async function(){
                    let title = $("#articleTitleInputVal").val();
                    let picture = document.getElementById("pictureVal");

                    if (title === "") {
                        alert("Title can't be empty!");
                        return showNewArticleDialog();
                    }
                    
                    if (picture !== "" && picture.files[0] != null) {
                        let binary = await toBase64(picture.files[0]);
                        picture = binary;
                    } 
                    else {
                        picture = null;
                    }
                    
                    createArticle(categoryId, title, picture);
                }
            }
        ]
    });
}

function createArticle(categoryId, title, picture = null) {
    let data = {
        "title": title,
        "image": picture
    };

    let url = `article/${categoryId}`;

    post(url, data).then(res => {
        if (res.status === 200) {
            location.reload();
        }
        else {
            alert(res.status);
        }
    });
}

function showArticleDeleteDialog(categoryId, articleId, title) {
    Metro.dialog.create({
        title: "Delete article",
        content: `Do you want to delete "${title}"?`,
        closeButton: true,
        actions: [
            {
                caption: "Yes",
                cls: "js-dialog-close alert",
                onclick: function(){
                    deleteArticle(categoryId, articleId);
                }
            },
            {
                caption: "No",
                cls: "js-dialog-close success",
                onclick: function(){
                    return false;
                }
            }
        ]
    });
}

function deleteArticle(categoryId, articleId){
    let url = `article/${categoryId}/${articleId}`;
    window.delete(url).then(res => {
        if (res.status === 200) {
            window.location =`admin?currentCategoryId=${categoryId}`;
        }
        else {
            alert("Something went wrong.");
        }
    });
}

function showUpdateArticleDialog(categoryId, articleId, title, img, secondTitle){
    Metro.dialog.create({
        title: "Update Article",
        content: `<input type=\"text\" data-role=\"input\" placeholder="title" value="${title}" id="articleTitleInputVal">
                  <hr />
                  <input type=\"text\" data-role=\"input\" placeholder="title" value="${secondTitle}" id="articleSecondTitleInputVal" >
                  <hr />
                  <img src="${img}" alt="current Picture" width="50%" height="50%" id="currentPicture"/>
                  <hr />
                  <input type="file" data-role="file" data-prepend="Select article picture:" id="pictureVal" onchange="previewFile(this);">
                  <script>
                    function previewFile(input){
                        let file = $("input[type=file]").get(0).files[0];
                        if(file){
                            let reader = new FileReader();
                            reader.onload = function(){
                                $("#currentPicture").attr("src", reader.result);
                            }
                            reader.readAsDataURL(file);
                        }
                    }
                  </script>`,
        closeButton: true,
        actions: [
            {
                caption: "Yes",
                cls: "js-dialog-close alert",
                onclick: async function(){
                    let title = document.getElementById("articleTitleInputVal").value;
                    let secondTitle = document.getElementById("articleSecondTitleInputVal").value;
                    let image = document.getElementById("pictureVal");
                    
                    if (image !== "undefined" && image !== "" && image.files[0] != null) {
                        image = await toBase64(image.files[0]);
                    } else {
                        image = null;
                    }
                    
                    title = title === "" || title === "undefined" ? null : title;
                    secondTitle = secondTitle === "" || secondTitle === "undefined" ? null : secondTitle;
                    
                    updateArticle(categoryId, articleId, title, secondTitle, image);
                }
            },
            {
                caption: "No",
                cls: "js-dialog-close success",
                onclick: function(){
                    return false;
                }
            }
        ]
    });
}

function increasePosition(categoryId, articleId, currentPosition){
    let position = parseInt(currentPosition);
    position = !Number.isNaN(position) ? position : null;
    updateArticle(categoryId, articleId, null, null, null, position, true);
}

function decreasePosition(categoryId, articleId, currentPosition){
    let position = parseInt(currentPosition);
    position = !Number.isNaN(position) ? position : null;
    updateArticle(categoryId, articleId, null, null, null, position, false);
}

function updateArticle(categoryId, articleId, title, secondTitle, img, position = null, isUp = null){
    let url = `article/${categoryId}/${articleId}`;
    
    let data = {
        "title": title,
        "secondTitle": secondTitle,
        "image": img,
        "isUp": isUp,
        "isDown": isUp == null ? null : !isUp,
        "position": position
    };
    
    window.put(url, data).then(res => {
        if (res.status === 200) {
            location.reload();
        }
        else {
            alert("Something went wrong.");
        }
    });
}



