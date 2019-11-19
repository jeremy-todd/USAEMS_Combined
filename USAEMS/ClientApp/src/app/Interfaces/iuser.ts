export interface IUser {
    id: String;
    firstName: String;
    lastName: String;
    securityQuestion: Number;
    securityAnswer: String;
    email: String;
    phoneNumber:String;
    carrierId: Number;
    student: Boolean;
    technical: Boolean;
    employerId: Number;
    active: Boolean;
    token?: String;
}
