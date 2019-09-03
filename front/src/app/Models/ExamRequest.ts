export class ExamRequest {
    id:number;  //n
    hypothesis : string;
    expectedDate : string;
    examName: string; 
    recomendation: string;
    medicCrm : number; //n
    patientId: number;
    medicName: string;
    patientName: number;

}

export enum TypeExam {
    ecocardiograma = 0,
    eletrocardiograma = 1,
    mapa = 2,
    holter =3
}