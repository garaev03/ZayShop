let mainBox = document.querySelector(".main-box")
let main = document.querySelector(".main")
let addMain = document.querySelectorAll(".add-main")
addMain.forEach(btn => {
    btn.addEventListener("click", () => {
        let newMain=document.createElement("div")
        newMain.setAttribute("class","mt-3")

        let minusBtn=document.createElement("a")
        minusBtn.setAttribute("class","remove-main mt-2 btn btn-sm btn-danger text-light")
        minusBtn.innerHTML=`<i class="fas fa-minus"></i>`

        newMain.innerHTML=main.outerHTML+minusBtn.outerHTML
        mainBox.appendChild(newMain)

        minusMain()
    })
})

function minusMain(){
    let minus=document.querySelectorAll(".remove-main")
    minus.forEach(btn=>{
        btn.addEventListener("click",()=>{
            btn.parentElement.remove()
        })
    })
}