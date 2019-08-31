export class ExamRequest {
    id:number;
    crm_medico : number;
    type_exame: string;
    data_prevista : Date;
    recomendacao : string;
    hipotese_cid: string;
    id_paciente: number;
}

export enum TypeExam {
    ecocardiograma = 0,
    eletrocardiograma = 1,
    mapa = 2,
    holter =3
}