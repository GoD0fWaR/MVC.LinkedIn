//var addHashtag = document.querySelector('.mypost-hashtag');
//addHashtag.addEventListener('click', function (e) {
//    document.getElementById('textEditor').value += "#";
//});

//var onAddBtn = function (e) {
//    //1.get Data from input fields
//    var inputComment = document.querySelector(".inputComment").value;
//    document.querySelector('.comment-sec').style.display = 'block';
//    document.querySelector('.comment--text').innerHTML += inputComment;
//    console.log(inputComment);
//    console.log(onAddBtn);

//};

//document.addEventListener('keypress', function (event) {
//    if (event.keyCode === 13 || event.which === 13) {
//        onAddBtn(event);
//    }
//});

//document.querySelector('.comment-like').addEventListener('click', function () {
//    document.querySelector('.comment-like').classList.toggle('text-primary');
//    document.querySelector('.likes-no').classList.toggle('pr-2');
//    document.querySelector('.likes-no').classList.toggle('d-inline');

//});

//document.querySelector('.option-click').addEventListener('click', function () {
//    document.querySelector('.comment-options').classList.toggle('d-block');
//});

//$('#myModal').on('shown.bs.modal', function () {
//    $('#myInput').trigger('focus')
//})


////////////////////////////SELECTORS//////////////////////////////////

// trigger for nextbutton to dismiss picture modal and show post modal with the same photos
const nextButton = document.getElementById("next-button");

//trigger for picture modal
const selectPhoto = document.getElementById("edit-post-photo");

// trigger for post modal
const startPost = document.getElementById("startPost");

// post modal container
const postModal = document.getElementById("post");
// picture modal container
const pictureModal = document.getElementById("picture");

// container to put images in picture modal
const editPostPhotoContainer = document.getElementById("edit-post-photo-container");
// container to put images in post modal
const submitPostPhotoContainer = document.getElementById("submit-post-photo-container");

// variable for postbodytext 
const postBodyText = document.getElementById('textEditor');

postBodyText.addEventListener('input', function (e) {
    let postBodyTextValue = postBodyText.value;

    if (postBodyTextValue == null || postBodyTextValue.trim() == "") {
        validatePostButton(false);

    }
    else {
        validatePostButton(true);
    }
});

// add event on picture modal trigger to rest the container of images in picture modal
selectPhoto.addEventListener("click", function () {
    editPostPhotoContainer.innerHTML = "";
})

// add event on post modal trigger to rest the container of images in post modal
startPost.addEventListener("click", function () {
    submitPostPhotoContainer.innerHTML = "";
    validatePostButton(false);
})

selectPhoto.addEventListener("change", handleFiles, false);

// function to handle uploaded images and fire trigger for nextbutton and check for next button availibilty
function handleFiles() {
    const fileList = this.files; /* work with the file list */
    console.log(fileList);
    // hide the postModal behind pictureModal
    // chech next button 
    if (fileList != null) {
        // adjust html elements for photos

        displayFileListInContainer(fileList, editPostPhotoContainer);

        nextButton.addEventListener("click", callPostModal(fileList, submitPostPhotoContainer));
        validatePostButton(true);
    } else {
        validatePostButton(false)
    }
}


function callPostModal(fileList, container) {
    displayFileListInContainer(fileList, container);


}

function displayFileListInContainer(fileList, container) {
    container.innerHTML = "";
    for (var i = 0; i < fileList.length; i++) {
        const photoElement = document.createElement("div");
        container.appendChild(photoElement);

        const img = document.createElement("img");
        img.src = URL.createObjectURL(fileList[i]);
        img.className = "uploaded-image";
        img.onload = function () {
            URL.revokeObjectURL(this.src);
        }
        photoElement.appendChild(img);
    }
}


function validatePostButton(flag) {
    if (flag) {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishDisable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishEnable');
    }
    else
    {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishEnable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishDisable');
    }

}