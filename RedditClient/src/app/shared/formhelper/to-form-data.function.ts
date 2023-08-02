export function toFormData(formValue: any): FormData {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {

        const k: string = key as string; 
        const value = formValue[k];

        formData.append(k, value);
    }
    return formData;
}