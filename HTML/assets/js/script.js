function cadaster(){
    let _nome = document.getElementById('name').value;
    let _sobrenome = document.getElementById('lastName').value;
    let _telefone = document.getElementById('tel').value;
    let _ra = document.getElementById('RA').value;
    

    let aluno = {
        nome: _nome,
        sobrenome :_sobrenome,
        tel: _telefone,
        ra: _ra
    }
}

function loadStudents(){
    let xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:44305/api/Aluno', true);

    xhr.onload = function(){
        let student = JSON.parse(this.responseText);
        for(let indice in student){
            addLine(student[indice]);
        }
    }
    xhr.send();
}

loadStudents();

function editStudent(id) {
    console.log(id)
}


function addLine(student){
    let tbody = document.querySelector('table tbody');

    let trow = `<tr>
                    <td>${student.name}</td>
                    <td>${student.lastName}</td>
                    <td>${student.tel}</td>
                    <td>${student.ra}</td>
                    <td><button onclick='editStudent(${student.id})'>Editar</button></td>
                </tr>
                `
    tbody.innerHTML+=trow;
}
