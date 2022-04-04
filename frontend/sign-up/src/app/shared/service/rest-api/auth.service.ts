import { Injectable } from '@angular/core';
import { RestApiService } from './rest-api.service';
import { Observable } from 'rxjs';
import { ISignUpDto } from '../../model/signup.dto';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	public constructor(private restService: RestApiService) {}

	public signUp(dto: ISignUpDto): Observable<string> {
		return this.restService.Post<string>('Auth/SignUp', dto);
	}
}
