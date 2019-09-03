export class ExamRequest {
    id:number;  //n
    medicCrm : number; //n
    medicName: string;
    examName: string; 
    expectedDate : string;
    hypothesis : string;
    recomendation: string;
    patientId: number;
    patientName: number;

}

export enum TypeExam {
    ecocardiograma = 0,
    eletrocardiograma = 1,
    mapa = 2,
    holter =3
}