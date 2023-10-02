var prev = document.getElementById("prev");
var cover = document.getElementById("cover");
document.addEventListener("DOMContentLoaded", excute);
function excute() {
    cover.addEventListener("change", (e) => {
        prev.classList.remove("d-none");
        const file = e.target.files[0];
        const url = URL.createObjectURL(file);
        document.getElementById("prev").src = url;
        $("#cover").valid();
    })
}