let tbody = document.querySelector('table tbody');
let aluno = {};

function cadaster(){
    aluno.name = document.querySelector('#name').value;
    aluno.lastName  = document.querySelector('#lastName').value;
    aluno.tel = document.querySelector('#tel').value;
    aluno.ra = document.querySelector('#ra').value;


    if (aluno.id === undefined || aluno.id ===0) {
        saveStudents('POST', 0, aluno);
    }
    else{
        saveStudents('PUT',aluno.id, aluno);
    }
    loadStudents();
}

function loadStudents(){
    tbody.innerHTML='';

    let xhr = new XMLHttpRequest();


    xhr.open('GET', `https://localhost:44305/api/Aluno`, true);

    xhr.onload = function(){
        let student = JSON.parse(this.responseText);
        for(let indice in student){
            addLine(student[indice]);
        }
    }
    xhr.send();
}

function saveStudents(method, id, body){
    
    let xhr = new XMLHttpRequest();

    if(id === undefined || id === 0){
        id = '';
    }
    //false para esperar se a execução está sendo feito de forma correta, após isso ira atualizar e aceitar

    xhr.open(method, `https://localhost:44305/api/Aluno/${id}`, false);

    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(body));
    
}

function deleteStudent(id) {
    let xhr = new XMLHttpRequest();

    xhr.open('DELETE', `https://localhost:44305/api/Aluno/${id}`, false);

    xhr.send();
}

function del(id) {
    deleteStudent(id);
    loadStudents();
}


loadStudents();


function editStudent(student) {
    let btnSave = document.querySelector('#btnSave');
    let btnCancel = document.querySelector('#btnCancel');
    let title = document.querySelector('#title');

    document.querySelector('#name').value = student.name;
    document.querySelector('#lastName').value = student.lastName;
    document.querySelector('#tel').value = student.tel;
    document.querySelector('#ra').value = student.ra;

    btnSave.textContent = 'Salvar';
    btnCancel.textContent = 'Cancelar';
    title.textContent = `Editar Aluno ${student.name}`;
    
    aluno = student;
}

function cancel() {
    let btnSave = document.querySelector('#btnSave');
    let btnCancel = document.querySelector('#btnCancel');
    let title = document.querySelector('#title');
    
    document.querySelector('#name').value = '';
    document.querySelector('#lastName').value = '';
    document.querySelector('#tel').value = '';
    document.querySelector('#ra').value = '';

    aluno = {};

    btnSave.textContent = 'Cadastrar';
    btnCancel.textContent = 'Limpar';
    title.textContent = 'Cadastrar Aluno';
    
    
}


function addLine(student){

    let trow = `<tr>
                    <td>${student.name}</td>
                    <td>${student.lastName}</td>
                    <td>${student.tel}</td>
                    <td>${student.ra}</td>
                    <td>
                        <button onclick='editStudent(${JSON.stringify(student)})'>Editar</button></td>
                        <button onclick='del(${student.id})'>Deletar</button>
                    </td>
                </tr>
                `
    tbody.innerHTML+=trow;
}
