export class ErrorsApi {
  errors: any[] | undefined;
  Validation: ErrorsValidation[] | undefined;
}

export class ErrorsValidation {
  key: string | undefined;
  message: string | undefined;
}
