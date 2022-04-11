import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../shared/service/logger.service';
import { StoreFacade } from '../../shared/facade/store.facade';
import { LogHelper } from '../../shared/helper/log.helper';

@Component({
	selector: 'app-signup',
	templateUrl: './signup.component.html',
	styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
	public constructor(private _logger: LoggerService, private _store: StoreFacade) {}

	public ngOnInit(): void {
		this._logger.info('SignupComponent ngOnInit');
	}

	public submit(step1: any, step2: any) {
		let payload = { ...step1, countryId: step2.country, provinceId: step2.province };

		this._logger.info(`submit ${LogHelper.pretty(payload)}`);

		this._store.signUpLoading(payload);
	}
}
