import { Injectable } from '@angular/core';

@Injectable()
export class LoggerService {
	public info(message: any) {
		console.info(message);
	}

	public debug(message: any) {
		console.debug(message);
	}

	public warn(message: any) {
		console.warn(message);
	}

	public error(...args: any[]) {
		console.error(args);
	}

	public verbose(message: any) {
		console.debug(message);
	}
}
